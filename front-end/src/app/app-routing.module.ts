import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './auth/registro/registro.component';


const routes: Routes = [
  { path: '', redirectTo: 'conta/registrar', pathMatch: 'full' },
  { path: 'conta/registrar', component: RegistroComponent },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module')
      .then(m => m.DashboardModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
