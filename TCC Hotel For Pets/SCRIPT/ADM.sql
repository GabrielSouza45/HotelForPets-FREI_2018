drop database tcc;

CREATE DATABASE `TCC`;

USE `tcc`;

select* from tb_funcionario;


CREATE TABLE `tb_Usuario` (
	`id_Usuario` INT NOT NULL AUTO_INCREMENT,
	`nm_Usuario` varchar(45) NOT NULL,
	`ds_CPF` varchar(15) NOT NULL,
	`ds_Telefone` varchar(45) NOT NULL,
	`ds_Celular` varchar(45)  NULL,
	`ds_email_usuario` varchar(45) NOT NULL,
	`ds_Senha_usuario` varchar(15) NOT NULL,
	`bt_adm` boolean default false,
    `bt_funcionario` boolean default false,
	PRIMARY KEY (`id_usuario`)
);

insert into tb_usuario (nm_usuario, ds_cpf, ds_telefone, ds_celular, ds_email_usuario, ds_senha_usuario, bt_adm, bt_funcionario)
		values ("gabriel", "422.778.648-70", "(11)59762358", "", "gfs@gfs.com", "123", true, false);

select * from tb_usuario;

CREATE TABLE `tb_cliente` (
	`id_cliente` INT NOT NULL AUTO_INCREMENT,
	`nm_nome` varchar(45) NOT NULL,
	`ds_cpf` INT NOT NULL UNIQUE,
	`ds_bairro` varchar(50) NOT NULL,
	`ds_cep` INT NOT NULL,
	`ds_rua` varchar(65) NOT NULL,
	`ds_telefone` varchar(45) NOT NULL,
	`id_animal` INT NOT NULL,
	`id_funcionario` INT NOT NULL,
	`ds_email_cliente` VARCHAR(45) NOT NULL UNIQUE,
	`ds_senha_cliente` VARCHAR(45) NOT NULL,
	PRIMARY KEY (`id_cliente`)
);

CREATE TABLE `tb_animal` (
	`id_animal` INT NOT NULL AUTO_INCREMENT,
	`ds_nome_animal` varchar(45) NOT NULL,
	`ds_especie` varchar(45) NOT NULL,
	`ds_pelagem` varchar(45) NOT NULL,
	`ds_porte` varchar(45) NOT NULL,
	`ds_raca` varchar(45) NOT NULL,
	`ds_cor` varchar(45) NOT NULL,
	`ds_castracao` BOOLEAN NOT NULL,
	`ds_carteira_vacinacao` varchar(45) NOT NULL,
	PRIMARY KEY (`id_animal`)
);

CREATE TABLE `tb_funcionario` (
	`id_funcionario` INT NOT NULL AUTO_INCREMENT,
	`nm_nome` varchar(45) NOT NULL,
	`ds_cpf` varchar(15) NOT NULL,
	`ds_cargo` varchar(45) NOT NULL,
    `ds_email_funcionario` varchar(45) NOT NULL UNIQUE,
	`ds_senha_funcionario` varchar(45) NOT NULL,
	`ds_data_de_nascimento` DATE NOT NULL,
	`ds_telefone` varchar(45) NOT NULL,
	`ds_rua` varchar(65) NOT NULL,
	`ds_bairro` varchar(45) NOT NULL,
	`ds_cep` INT NOT NULL,
	`nr_numero` varchar(7) NOT NULL,
	`ds_cidade` varchar(45) NOT NULL,
	`ds_estado` varchar(3) NOT NULL,
    `bt_adm` bool NOT NULL,
    `bt_funcionario` bool NOT NULL,
	PRIMARY KEY (`id_funcionario`)
);

CREATE TABLE `tb_fornecedor` (
	`id_fornecedor` INT NOT NULL AUTO_INCREMENT,
	`nm_nome` varchar(45) NOT NULL,
	`ds_telefone` varchar(45) NOT NULL,
	PRIMARY KEY (`id_fornecedor`)
);

CREATE TABLE `tb_produto` (
	`id_produto` INT NOT NULL AUTO_INCREMENT,
	`nm_produto` varchar(45) NOT NULL,
	`vl_preco` DECIMAL NOT NULL,
	`id_fornecedor` INT NOT NULL,
	PRIMARY KEY (`id_produto`)
);

CREATE TABLE `tb_pedido` (
	`id_pedido` INT NOT NULL AUTO_INCREMENT,
	`id_cliente` INT NOT NULL,
	`dt_venda` DATE NOT NULL,
	PRIMARY KEY (`id_pedido`)
);

CREATE TABLE `tb_pedido_item` (
	`id_pedido_item` INT NOT NULL AUTO_INCREMENT,
	`id_pedido` INT NOT NULL,
	`id_produto` INT NOT NULL,
	PRIMARY KEY (`id_pedido_item`)
);

  

CREATE TABLE `tb_folha_de_pagamento` (
	`id_folha_de_pagamento` INT NOT NULL AUTO_INCREMENT,
    `dt_emissao_folha` DATE NOT NULL,	
	`ds_salario` DECIMAL NOT NULL,
	`ds_horas_extras` varchar(10) NOT NULL,
	`ds_atrasos` varchar(3) NOT NULL,
	`ds_faltas` varchar(3) NOT NULL,
	`vl_inss` DECIMAL NOT NULL,
	`vl_imposto_de_renda` DECIMAL NOT NULL,
	`ds_aliquota` DECIMAL,
	`vl_fgts` DECIMAL NOT NULL,
	`vl_vale_transporte` DECIMAL NOT NULL,
	`vl_salario_liquido` DECIMAL NOT NULL,
    `id_Funcionario` INT NOT NULL,
	PRIMARY KEY (`id_folha_de_pagamento`)
);



CREATE TABLE `tb_Folha_Funcionario` (
	`Id_Folha` INT NOT NULL auto_increment,
    `pagm_id_folha_de_pagamento` INT NOT NULL,
    `func_id_funcionario` INT NOT NULL,
    PRIMARY KEY (`id_folha`)
);

CREATE TABLE `tb_estoque` (
	`id_estoque` INT NOT NULL AUTO_INCREMENT,
	`qt_produto` varchar(10) NOT NULL,
	`vl_custo_atual` DECIMAL NOT NULL,
	`vl_custo_total` DECIMAL NOT NULL,
	`Produto_id_produto` INT NOT NULL,
	PRIMARY KEY (`id_estoque`)
);

CREATE TABLE `tb_fluxo_de_caixa` (
	`id_fluxo_de_caixa` INT NOT NULL AUTO_INCREMENT,
	`ds_descricao` INT NOT NULL,
	`ds_valor` DECIMAL NOT NULL,
	`ds_saldo_atual` DECIMAL NOT NULL,
	`vl_saldo_dia` DECIMAL NOT NULL,
	`vl_subtotal` DECIMAL NOT NULL,
	`id_pedido` INT NOT NULL,
	PRIMARY KEY (`id_fluxo_de_caixa`)
);

CREATE TABLE `tb_administrador` (
	`id_administrador` INT NOT NULL AUTO_INCREMENT,
	`nm_nome` varchar(45) NOT NULL,
	`ds_cpf` varchar(11) NOT NULL,
	`ds_email_administrador` varchar(45) NOT NULL UNIQUE,
	`ds_senha_administrador` varchar(45) NOT NULL,
	`ds_data_de_nascimento` DATE NOT NULL,
	`ds_telefone` varchar(45) NOT NULL,
	`ds_rua` varchar(65) NOT NULL,
	`ds_bairro` varchar(45) NOT NULL,
	`ds_cep` INT NOT NULL,
	`nr_numero` varchar(7) NOT NULL,
	`ds_cidade` varchar(45) NOT NULL,
	`ds_estado` varchar(3) NOT NULL,
	`pagm_id_folha_de_pagamento` INT NOT NULL,
	PRIMARY KEY (`id_administrador`)
);

select * from tb_login;

CREATE TABLE `tb_login` (
	`id_login` INT NOT NULL AUTO_INCREMENT,
    
	PRIMARY KEY (`id_login`)
);

ALTER TABLE `tb_Folha_Funcionario` ADD CONSTRAINT `tb_Folha_Funcionario_fk0` FOREIGN KEY (`pagm_id_folha_de_pagamento`) REFERENCES `tb_folha_de_pagamento`(`id_folha_de_pagamento`);

ALTER TABLE `tb_Folha_Funcionario` ADD CONSTRAINT `tb_Folha_Funcionario_fk1` FOREIGN KEY (`func_id_funcionario`) REFERENCES `tb_funcionario`(`id_funcionario`);

ALTER TABLE `tb_cliente` ADD CONSTRAINT `tb_cliente_fk0` FOREIGN KEY (`id_animal`) REFERENCES `tb_animal`(`id_animal`);

ALTER TABLE `tb_cliente` ADD CONSTRAINT `tb_cliente_fk1` FOREIGN KEY (`id_funcionario`) REFERENCES `tb_funcionario`(`id_funcionario`);

ALTER TABLE `tb_folha_de_pagamento` ADD CONSTRAINT `tb_folha_de_pagamento_fk0` FOREIGN KEY (`id_funcionario`) REFERENCES `tb_funcionario`(`id_funcionario`);

ALTER TABLE `tb_produto` ADD CONSTRAINT `tb_produto_fk0` FOREIGN KEY (`id_fornecedor`) REFERENCES `tb_fornecedor`(`id_fornecedor`);

ALTER TABLE `tb_pedido` ADD CONSTRAINT `tb_pedido_fk0` FOREIGN KEY (`id_cliente`) REFERENCES `tb_cliente`(`id_cliente`);

ALTER TABLE `tb_pedido_item` ADD CONSTRAINT `tb_pedido_item_fk0` FOREIGN KEY (`id_pedido`) REFERENCES `tb_pedido`(`id_pedido`);

ALTER TABLE `tb_pedido_item` ADD CONSTRAINT `tb_pedido_item_fk1` FOREIGN KEY (`id_produto`) REFERENCES `tb_produto`(`id_produto`);

ALTER TABLE `tb_estoque` ADD CONSTRAINT `tb_estoque_fk0` FOREIGN KEY (`Produto_id_produto`) REFERENCES `tb_produto`(`id_produto`);

ALTER TABLE `tb_fluxo_de_caixa` ADD CONSTRAINT `tb_fluxo_de_caixa_fk0` FOREIGN KEY (`id_pedido`) REFERENCES `tb_pedido`(`id_pedido`);

ALTER TABLE `tb_administrador` ADD CONSTRAINT `tb_administrador_fk0` FOREIGN KEY (`pagm_id_folha_de_pagamento`) REFERENCES `tb_folha_de_pagamento`(`id_folha_de_pagamento`);

ALTER TABLE `tb_login` ADD CONSTRAINT `tb_login_fk0` FOREIGN KEY (`fucionario_id_funcionario`) REFERENCES `tb_funcionario`(`id_funcionario`);

ALTER TABLE `tb_login` ADD CONSTRAINT `tb_login_fk1` FOREIGN KEY (`cliente_id_cliente`) REFERENCES `tb_cliente`(`id_cliente`);

ALTER TABLE `tb_login` ADD CONSTRAINT `tb_login_fk2` FOREIGN KEY (`administrador_id_administrador`) REFERENCES `tb_administrador`(`id_administrador`);



 CREATE VIEW VW_CONSULTAR_LOGIN AS
	select tb_login.id_login,
		   tb_cliente.id_cliente,
		   tb_cliente.ds_email_cliente,
		   tb_cliente.ds_senha_cliente,
           tb_funcionario.id_funcionario,
		   tb_funcionario.ds_email_funcionario,
		   tb_funcionario.ds_senha_funcionario,
           tb_administrador.id_administrador,
		   tb_administrador.ds_email_administrador,
		   tb_administrador.ds_senha_administrador
	from tb_login
    join tb_cliente
      on tb_login.cliente_id_cliente
	join tb_funcionario
      on tb_login.fucionario_id_funcionario
    join tb_administrador
      on tb_login.administrador_id_administrador;
      
      select * from VW_CONSULTAR_LOGIN;



CREATE VIEW VW_CONSULTAR_FUNCIONARIO AS
	select 	tb_Folha_Funcionario.Id_Folha,
			tb_funcionario.id_funcionario,
            tb_funcionario.nm_nome,
            tb_funcionario.ds_cargo,
            tb_funcionario.ds_telefone,
            tb_funcionario.ds_email_funcionario,
            tb_folha_de_pagamento.id_folha_de_pagamento,
            tb_folha_de_pagamento.dt_emissao_folha,
            tb_folha_de_pagamento.vl_salario_liquido
	from tb_Folha_Funcionario
    join tb_funcionario
    on	tb_Folha_Funcionario.func_id_funcionario
    join tb_folha_de_pagamento
    on	tb_Folha_Funcionario.pagm_id_folha_de_pagamento;
            
            
      select * from VW_CONSULTAR_FUNCIONARIO;