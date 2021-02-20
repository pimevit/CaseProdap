Feature: AdicionarVenda
	In order to avoid silly mistakes
	As a math idiot
	I want

@mytag
Scenario: Adicionar Picole no carrinho
	Given carrinho está vazio
	When adicionar 1 do produto S311 no carrinho
	Then a quantidade do carrinho deve ser 1

Scenario: Adicionar Picole no carrinho e Vender
	Given carrinho está vazio
	When adicionar 2 do produto S312 no carrinho
	When adicionar 2 do produto S314 no carrinho
	Then a quantidade do carrinho deve ser 4

Scenario: Sincronizar Vendas do carrinho 
	Given carrinho está vazio
	When adicionar 1 do produto S1313 no carrinho
	And vender 1 do produto S1313 do carrinho
	And sincronizar venda
	Then a quantidade do carrinho deve ser 0