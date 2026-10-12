# ComChess

Jogo de xadrez em C# para jogar no terminal, desenvolvido para praticar **Programação Orientada a Objetos** e, aos poucos, evoluir para uma aplicação com banco de dados e interface web.

> Projeto de estudo em desenvolvimento. O motor do jogo (regras e peças) está avançado; a interface de partida completa, a persistência e a versão web estão no roadmap.

## Tecnologias

- C# / .NET 8
- Aplicação de console (terminal)

## Como executar

Pré-requisito: [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.

```bash
git clone https://github.com/JLucasFreitas/ComChess.git
cd ComChess
dotnet run
```

## Conceitos de POO aplicados

- **Abstração e herança:** a classe base `Pieces` define o comportamento comum, e cada peça (`Pawn`, `Rook`, `Knight`, `Bishop`, `Queen`, `King`) herda dela.
- **Polimorfismo:** cada peça sobrescreve as próprias regras de movimentação.
- **Métodos abstratos:** `ClonePiece` permite copiar o estado do tabuleiro, usado para simular jogadas.
- **Encapsulamento:** `Tabuleiro`, `Partida` e `Player` com responsabilidades separadas.

## Estrutura do projeto

| Arquivo | Responsabilidade |
|---|---|
| `Tabuleiro.cs` | Estado do tabuleiro e exibição no terminal |
| `Partida.cs` | Controle da partida e dos turnos |
| `Player.cs` | Representação do jogador |
| `Pieces.cs` | Classe base abstrata das peças |
| `Pawn.cs`, `Rook.cs`, `Knight.cs`, `Bishop.cs`, `Queen.cs`, `King.cs` | Regras de cada peça |

## Status atual

- [x] Tabuleiro exibido no terminal com emojis
- [x] Regras de movimentação das peças
- [x] Captura de peças
- [x] Roque
- [x] En passant
- [x] Cópia do tabuleiro para simular jogadas
- [ ] Detecção de xeque
- [ ] Xeque-mate e empate
- [ ] Desfazer movimento

## Roadmap

**Aplicação de terminal**

- [x] Pedir e guardar o nome dos dois jogadores no início
- [ ] Turnos alternados, começando pelo jogador das brancas
- [x] Jogadas no formato letra + número (por exemplo `e2`): escolher a peça e depois a casa de destino
- [ ] Encerrar a partida por xeque-mate ou empate
- [ ] Salvar cada lance de cada partida em um banco de dados SQL

**Versão web**

- [ ] API em C# (backend) reaproveitando o motor do jogo
- [ ] Front-end em JavaScript, rodando localmente

## Autor

**João Lucas Freitas** — estudante de Ciência da Computação no IFCE Maracanaú.
GitHub: [@JLucasFreitas](https://github.com/JLucasFreitas)
