/* Ficha Tecnica Faci_Logicol: */

CREATE TABLE Ingrediente (
    qtde decimal,
    idIngrediente int auto_increment PRIMARY KEY,
    fk_Receita_idReceita varchar(10),
    fk_Produto_idProduto int
);

CREATE TABLE Receita (
    idReceita varchar(10) PRIMARY KEY,
    data datetime,
    MargemLucro double,
    ValorMaoObra double,
    validade datetime,
    descricaoReceita varchar(255),
    Rendimento varchar(255)
);

CREATE TABLE Pedido (
    codigoPedido varchar(10) PRIMARY KEY,
    dataPedido datetime,
    statusPedido int,
    PrazoEntrega datetime,
    CustosAdicionais double,
    dataFechamento datetime,
    nomeCliente varchar(100),
    whatsApp varchar(100)
);

CREATE TABLE Pagamento (
    idPagamento int auto_increment PRIMARY KEY,
    tipoPagamento int,
    valorPagamento double,
    fk_Pedido_codigoPedido varchar(10),
    fk_Caixa_codigoCaixa varchar(10)
);

CREATE TABLE Caixa (
    codigoCaixa varchar(10) PRIMARY KEY,
    HoraAbert datetime,
    HoraFechamento datetime,
    valorInicio double,
    totalEntrada double,
    totalSaida double,
    valorFechamento double,
    ValorQuebra double,
    status int
);

CREATE TABLE Fluxo (
    idFluxo int auto_increment PRIMARY KEY,
    descricao varchar(100),
    valor double,
    tipo int,
    horario datetime,
    data datetime,
    fk_Caixa_codigoCaixa varchar(10)
);

CREATE TABLE Produto (
    idProduto int auto_increment PRIMARY KEY,
    PrecoEmbalagem double,
    ConteudoEmbalagem double,
    UN int,
    descricao varchar(255)
);

CREATE TABLE Venda (
    fk_Receita_idReceita varchar(10),
    fk_Pedido_codigoPedido varchar(10)
);
 
ALTER TABLE Ingrediente ADD CONSTRAINT FK_Ingrediente_2
    FOREIGN KEY (fk_Receita_idReceita)
    REFERENCES Receita (idReceita)
    ON DELETE RESTRICT;
 
ALTER TABLE Ingrediente ADD CONSTRAINT FK_Ingrediente_3
    FOREIGN KEY (fk_Produto_idProduto)
    REFERENCES Produto (idProduto)
    ON DELETE CASCADE;
 
ALTER TABLE Pagamento ADD CONSTRAINT FK_Pagamento_2
    FOREIGN KEY (fk_Pedido_codigoPedido)
    REFERENCES Pedido (codigoPedido)
    ON DELETE RESTRICT;
 
ALTER TABLE Pagamento ADD CONSTRAINT FK_Pagamento_3
    FOREIGN KEY (fk_Caixa_codigoCaixa)
    REFERENCES Caixa (codigoCaixa)
    ON DELETE CASCADE;
 
ALTER TABLE Fluxo ADD CONSTRAINT FK_Fluxo_2
    FOREIGN KEY (fk_Caixa_codigoCaixa)
    REFERENCES Caixa (codigoCaixa)
    ON DELETE CASCADE;
 
ALTER TABLE Venda ADD CONSTRAINT FK_Venda_1
    FOREIGN KEY (fk_Receita_idReceita)
    REFERENCES Receita (idReceita)
    ON DELETE RESTRICT;
 
ALTER TABLE Venda ADD CONSTRAINT FK_Venda_2
    FOREIGN KEY (fk_Pedido_codigoPedido)
    REFERENCES Pedido (codigoPedido)
    ON DELETE SET NULL;