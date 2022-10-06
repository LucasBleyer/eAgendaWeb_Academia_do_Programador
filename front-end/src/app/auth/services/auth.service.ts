import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { RegistrarUsuarioViewModel } from "../view-models/registrar-usuario.view-model";
import { TokenViewModel } from "../view-models/token.view-model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public registrarUsuario(registro: RegistrarUsuarioViewModel): Observable<TokenViewModel> {
    const resposta = this.http
      .post(this.apiUrl + "conta/registrar", registro, this.obterHeaderJson())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta;
  }

  private processarDados(resposta: any) {
    if (resposta.sucesso)
      return resposta.dados;
  }

  private processarFalha(resposta: any) {
    return throwError(() => new Error(resposta.error.erros[0]));
  }

  private obterHeaderJson(){
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }
  }
}
