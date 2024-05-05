
using FluentValidation;
using TC.Busines.Models;

namespace TC.Busines.Services;
public abstract class BaseService
{
    protected void Notificar(string mensagem)
    {

    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) 
        where TV: AbstractValidator<TE>
        where TE : Entity
    {  
        var validator = validacao.Validate(entidade);
        if (validator.IsValid)        
            return true;
        return false;
    }
}
