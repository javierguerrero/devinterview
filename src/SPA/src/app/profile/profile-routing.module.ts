import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileLayoutComponent } from './layouts/profile-layout/profile-layout.component';

const routes: Routes = [{
  path: '',
  component: ProfileLayoutComponent,
  //children
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
