# Challenge Chat
O projeto foi criar com Serviço API Rest fornecendo um WebSocket para Comunicar com qualquer outro Cliente que deseje se conectar ao Chat. O projeto poderia
ter ficado ainda melhor, demorei devido a nunca ter trabalhado com WebSocket e não gostaria de entregar qualquer coisa mesmo no pequeno período que tinha. Conforme coloquei
abaixo tem muitas melhorias para vir no futuro e processo utilizado para criar este.

Este projeto foi construido pensando nas boas práticas da programação.
***OBS> Acredito não ser necessario tamanha compressidade colocada nesta estrutura, mais como intuito é mostrar que consigo trabalhar com projetos bem estruturados.
***Arquitetura> Clean architecture, N-layer, DDD (Abastração Pequena das Ideias), REST
***Padrões de Projeto> Repository, Unit of Work, SOLID

***Melhorias de Arquitetura>Domain Validation, Projetos de Teste para Todas Camadas, Docker, Docker Compose, Angular Projeto, Autenticação (JWT), Autorização (JWT), 
WebJob (Para Salvar toda noite Historico)


***OBS> Abaixo irei citar as futuras funcionalidades e bugs encontrados.

*bugFix> Formatar Texto Digitado para Pt-BR
*feature> Criar Novas Salas, Navegar Entre Salas, Criar Usuario no Identity, Logar com Identity, Gerenciar Permissões com Claims, Votar para Excluir, Denunciar Comportamento e etc.
