import { NgModule } from '@angular/core';
import { Error404PageComponent } from './pages/error404-page/error404-page.component';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { tokenInterceptor } from './interceptors/token.interceptor';

@NgModule({
  declarations: [Error404PageComponent],
  exports: [Error404PageComponent],
  providers: [provideHttpClient(withInterceptors([tokenInterceptor]))],
})
export class SharedModule {}
