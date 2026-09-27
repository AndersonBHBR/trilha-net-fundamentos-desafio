# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial + precoPorHora × horas**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.


## Implementação concluída

Os métodos de cadastro, remoção e listagem e as quatro opções do menu estão implementados.
O projeto mantém o destino original **.NET 6**, sem pacotes externos.

### Como executar

Com o SDK .NET 6 instalado, abra um terminal na pasta que contém este README:

```powershell
dotnet run --project ./DesafioFundamentos/DesafioFundamentos.csproj
```

Para apenas compilar:

```powershell
dotnet build ./DesafioFundamentos/DesafioFundamentos.csproj
```

### Regras e decisões

- A cobrança é `precoInicial + precoPorHora * horas`, conforme a orientação do código original. A fórmula no enunciado foi corrigida, pois ignorava as horas informadas.
- Exemplo: taxa inicial de R$ 5,00, preço por hora de R$ 2,50 e 3 horas resultam em **R$ 12,50**.
- Preços aceitam zero e valores positivos; use vírgula para centavos e não use separador de milhar.
- Horas aceitam números inteiros não negativos. Zero horas cobra somente a taxa inicial; não há arredondamento de horas fracionárias.
- Placas são convertidas para maiúsculas, com remoção de hífens e espaços nas bordas. `abc-1234` e `ABC1234` identificam o mesmo veículo.
- Não são aceitas placas vazias nem repetidas. Não há validação do padrão oficial de placas, pois o desafio apenas exige guardar a identificação em uma lista.
- Entradas numéricas inválidas são solicitadas novamente. Uma remoção inválida mantém o veículo na lista.
- Os dados ficam em memória e são descartados ao encerrar, conforme o escopo do desafio.
- O menu reaparece após cada operação, sem exigir uma tecla adicional. A opção 4 ou o fim da entrada encerra o programa.

### Roteiro para conferência

1. Informe os preços `5,00` e `2,50`.
2. Escolha `3`: deve aparecer “Não há veículos estacionados”.
3. Escolha `1` e cadastre `abc-1234`.
4. Tente cadastrar `ABC1234` novamente: deve informar que o veículo já está estacionado.
5. Escolha `3`: deve listar apenas `ABC1234`.
6. Escolha `2`, informe `abc1234` e `3` horas: deve remover o veículo e cobrar R$ 12,50.
7. Escolha `3`: o estacionamento deve estar vazio novamente.
8. Tente remover uma placa inexistente; teste também preços negativos, horas inválidas e uma opção de menu inexistente.
9. Escolha `4` para encerrar.


### Verificação realizada

O código foi compilado com o compilador C# (Roslyn) do SDK 6.0.428 e executado com o runtime .NET 6.0.36. Dez cenários automatizados passaram, incluindo cadastro, duplicidade, listagem, cálculo e remoção, entradas inválidas, zero horas, tarifas gratuitas, limite numérico e encerramento por fim da entrada.

O comando `dotnet build` não pôde ser validado neste ambiente devido a uma falha de consulta de informações de processos do próprio SDK. A compilação e os testes foram feitos diretamente com Roslyn e o runtime, sem alterar o destino do projeto.

O ZIP contém os fontes e o diagrama. Pastas `.git`, `bin` e `obj` foram excluídas da entrega; ao atualizar um clone existente, mantenha sua pasta `.git` local.
