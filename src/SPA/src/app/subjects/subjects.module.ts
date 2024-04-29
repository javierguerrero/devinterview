import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicationsRoutingModule } from './subjects-routing.module';
import { SubjectPageComponent } from './pages/subject-page/subject-page.component';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { ListPageComponent } from './pages/list-page/list-page.component';
import { MaterialModule } from '../material/material.module';
import { CardComponent } from './components/card/card.component';

@NgModule({
  declarations: [
    SubjectPageComponent,
    LayoutPageComponent,
    ListPageComponent,
    CardComponent,
  ],
  imports: [CommonModule, ApplicationsRoutingModule, MaterialModule],
})
export class SubjectsModule {}
