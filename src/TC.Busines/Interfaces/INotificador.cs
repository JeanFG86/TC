using TC.Busines.Notificacoes;

namespace TC.Busines.Interfaces;
public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}
