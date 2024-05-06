
using FluentValidation;
using FluentValidation.Results;
using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Busines.Notificacoes;

namespace TC.Busines.Services;
public abstract class BaseService
{
    private readonly INotificador _notificador;

    public BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            Notificar(item.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
        where TV : AbstractValidator<TE>
        where TE : Entity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }

}
