import { Injectable } from "@angular/core";
import { TokenViewModel } from "../view-models/token.view-model";
import { UsuarioTokenViewMdel } from "../view-models/usuario-token.view-model";

@Injectable()
export class LocalStorageService {

  public salvarDadosLocaisUsuario(resposta: TokenViewModel): void {
    this.salvarTokenUsuario(resposta.chave);
  }

  public salvarTokenUsuario(token: string) {
    localStorage.setItem('eAgenda.token', token)
  }

  public salvarUsuario(user: UsuarioTokenViewMdel) {
    const jsonString = JSON.stringify(user);

    localStorage.setItem('eAgenda.user', jsonString);
  }
}

