import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { RegistrarUsuarioViewModel } from "../view-models/registrar-usuario.view-model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public registrarUsuario(registro: RegistrarUsuarioViewModel): Observable<any> {
    const resposta = this.http.post(
      this.apiUrl + "conta/registrar", registro, this.obterHeaderJson()
      );

    return resposta;
  }

  private obterHeaderJson(){
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }
  }
}
