# AbpTest
Try to use ABP from a Ionic Angular App
Problem with loop after login caused by https://github.com/manfredsteyer/angular-oauth2-oidc and rxjs 7
Downgrading to rxjs 6 fixes the loop

To reproduce start backend: dotnet run \aspnet-core\src\Abp512.HttpApi.Host...
and angular frontend: npm start

login with admin/1q2w3E*
