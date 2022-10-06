import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistroComponent } from './registro/registro.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { LocalStorageService } from './services/local-storage.service';



@NgModule({
  declarations: [
    RegistroComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    LocalStorageService
  ],
})
export class AuthModule { }
