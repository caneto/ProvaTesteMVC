# ProvaTesteMVC

Como solicitado fiz, o que pude. Primeiro vou apresentar o que fiz.

1 - Já tinha um projeto meu de Sistema com Contro de Usuarios completo. 
2 - Modifiquei ele para apenas conter está funcionalidade.
3 - Ao tentar modificar a versão do Entty Model (não permitiu devido a um erro de versão do SQLServer 2014). 
4 - Estava tentando modificar isso para permitir o usar o modelo apresentado, mais devido erro e não ter solucionado, 
    deixei o modelo de dados original que não é muito diferente. Por este mesmo motivo não consegui migrar o banco de SQLData
    LocalDB (Pois precisava modificar o Model do Entty). 

5 - O projeto é feito em Visual Studio 2013 com .Net Frame 4.6 (Mvc Razor) com uso de BootStreep nas paginas, 
banco de dados Sql Server 2014, com as tabelas de tbl_usuario, tbl_perfil_usuario, tbl_tipo_usuario.

Para testar apos baixar o codigo copiar os 2 arquivos BPO_new.* (mdf e log) para a pasta de data do servidor sqlserver local.
Dentro do projeto no webconfig - connectionString = 'data source='nome da instancia', feito isso ele ira rodar normalmente, 
login caneto senha qualquer valor, esta sem conferencia.

Ps1 : Como não foi perguntado, não conheco muito bem o Angular (pois nunca fiz nenhum projeto). E em 24hs +- não daria tempo,
ver e tentar fazer algo.

Ps2: Como disse durante a conversa, nunca fiz um projeto do Zero em WebApi, apenas ja dei manutenção algumas vezes adicionando,
campos ou corrigindo erros de logica.

Ps3: Fiz em C#, pois achei mais facil, devido a fazer mais de 3 anos que não mexo direto com VB.net, e o projeto que tenho,
e feito em C#, e tenho usado mais C#.

<img src="https://github.com/caneto/ProvaTesteMVC/blob/master/Tela0BPO.png" width="40%">
<img src="https://github.com/caneto/ProvaTesteMVC/blob/master/Tela1BPO.png" width="40%">
<img src="https://github.com/caneto/ProvaTesteMVC/blob/master/Tela2BPO.png" width="40%"s>
