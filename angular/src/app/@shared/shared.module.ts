import { CoreModule } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { IonicModule } from '@ionic/angular';

import { LoaderComponent } from './loader/loader.component';

@NgModule({
  imports: [IonicModule, TranslateModule, CommonModule, CoreModule],
  declarations: [LoaderComponent],
  exports: [LoaderComponent, CoreModule],
})
export class SharedModule {}
