# BrunoDPO.WCF.Comunicacao
*Autor: Bruno Di Prinzio de Oliveira*

## Descrição
Exemplo de aplicação cliente-servidor desenvolvida em .NET Framework 4.8 utilizando o Windows Communication Foundation (WCF) como base para a comunicação.
Essa aplicação consiste em:
1) Servidor - Console Application responsável por gerenciar todos os clientes conectados e rotear as mensagens entre eles
2) Cliente - Aplicação Windows Forms contendo um formulário em que é possível se conectar ao servidor, enviar e receber mensagens de outros clientes
O principal objetivo desse projeto é concentrar todo meu conhecimento adquirido ao longo dos anos com esse mecanismo de comunicação entre processos.
Ele é meu guia para quando desenvolvo ou mantenho sistemas legados que se utilizam dessa tecnologia.

## Funcionamento
A comunicação entre cliente e servidor ocorre através dos contratos definidos nas interfaces. Dessa forma, temos:

ICliente
* ReceberMensagem() - Recebe uma mensagem e a exibe no formulário
* Ping() - Responde a uma solicitação de Ping
* Desconectar() - Desconecta do servidor devido a um pedido externo

IServidor
* ConectarCliente() - Armazena o cliente, associando a Origem e a Fila para esse endereço
* DesconectarCliente() - Remove o cliente dos possíveis receptores de mensagens
* EnviarMensagem() - Roteia o envio de uma mensagem para um Sistema e uma Fila específicos
* Ping() - Responde a uma solicitação de Ping

Dessa forma, é possível abrir canais de comunicação (nesse caso foi escolhido o protocolo TCP) em duas vias, ou seja, servidor com clientes e vice-versa.
Cada cliente pode interagir com o servidor pedindo para se conectar ou desconectar (caso esteja finalizando sua execução) e enviar mensagens a outros clientes.
Por sua vez, o servidor mantém em memória todos os clientes conectados para que, ao ser slicitado para enviar mensagem, encontre o cliente correto de destino.

## Mecanismos

O WCF possibilita que toda a parametrização relativa à conexão (seja ela o protocolo, a segurança, os endpoints existentes, etc) seja realizada através de entradas no arquivo de configuração.
Isso flexibiliza a forma de utilização sem que seja necessária alteração de código. Porém, como nesse cenário as conexões somente serão estabelecidas de uma única forma, foi escolhido utilizar tudo em código.
Além disso, o fato de haver conexão em duas vias, apesar de parecer mais complexo num primeiro momento, ajuda a demonstrar como mensagens podem fluir entre os processos, mesmo que estejam em máquinas diferentes.
