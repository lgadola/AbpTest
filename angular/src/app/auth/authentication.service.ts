import { Injectable } from '@angular/core';
import { catchError, finalize, lastValueFrom, Observable, of, throwError } from 'rxjs';
import { ToasterService } from '@abp/ng.theme.shared';

import { Credentials, CredentialsService } from './credentials.service';
import { OAuthService } from 'angular-oauth2-oidc';
import { AbpTenantService, AuthService, ConfigStateService, CurrentTenantDto, SessionStateService } from '@abp/ng.core';

export interface LoginContext {
  username: string;
  password: string;
  remember?: boolean;
}

/**
 * Provides a base for authentication workflow.
 * The login/logout methods should be replaced with proper implementation.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  name: string;

  isModalVisible: boolean;
  inProgress = false;
  modalBusy: boolean;

  constructor(
    private credentialsService: CredentialsService,
    private tenantService: AbpTenantService,
    private oAuthService: OAuthService,
    private authService: AuthService,
    private sessionState: SessionStateService,
    private configState: ConfigStateService,
    private toasterService: ToasterService
  ) {
    if (this.isMultiTenant()) {
      const tenant = this.sessionState.getTenant();
      this.tenantService
        .findTenantByName('Uster', {})
        .pipe(finalize(() => (this.modalBusy = false)))
        .subscribe(({ success, tenantId: id, ...tenant }) => {
          if (!success) {
            this.showError();
            return;
          }

          this.setTenant({ ...tenant, id, isAvailable: true });
        });
    }
  }

  /**
   * Authenticates the user.
   * @param context The login parameters.
   * @return The user credentials.
   */
  async login(context: LoginContext) {
    // Replace by proper authentication call
    const data = {
      username: context.username,
      token: '123456',
    };
    await this.authService
      .login({ username: context.username, password: context.password })
      .pipe(
        catchError((err) => {
          this.toasterService.error(
            err.error?.error_description || err.error?.error.message || 'AbpAccount::DefaultErrorMessage',
            null,
            { life: 7000 }
          );
          return throwError(() => new Error(err));
        }),
        finalize(() => this.credentialsService.setCredentials(data, context.remember))
      )
      .subscribe();
  }

  /**
   * Logs out the user and clear credentials.
   * @return True if the user was logged out successfully.
   */
  logout(): Observable<boolean> {
    // Customize credentials invalidation here
    this.oAuthService.logOut();
    this.credentialsService.setCredentials();
    return of(true);
  }
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
  async isMultiTenant() {
    var result = this.configState.getDeep$('multiTenancy.isEnabled');
    return await lastValueFrom(result);
  }
  private setTenant(tenant: CurrentTenantDto) {
    this.sessionState.setTenant(tenant);
    this.configState.refreshAppState();
  }
  private showError() {
    console.error('Tenant not found: ' + this.name);
  }
}
