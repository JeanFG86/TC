﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Busines.Notificacoes;
public class Notificacao
{
    public Notificacao(string mensagem)
    {
        Mensagem = mensagem;
    }

    public string? Mensagem { get; } 
}
