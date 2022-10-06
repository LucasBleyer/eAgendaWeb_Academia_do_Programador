import { UsuarioTokenViewModel } from "./usuario-token.view-model";

export class TokenViewModel {
  chave: string;
  dataExpiracao: Date;

  usuarioToken: UsuarioTokenViewModel;
}
