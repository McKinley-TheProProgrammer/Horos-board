# Horos-board
Repositório do Jogo de Cartas Horos⭐board, pela CosmicFox e Itsy Bitsy

VERSÃO DA UNITY: <p style="color:rgb(255,90,80)">2021.3.36f1(LFS)</p>

<b>Temática:</b>
Horos✰board é um Jogo de Estratégia de Cartas sobre Signos, Constelações e Mitologia Romana. O jogo apresenta a astrologia e os conceitos de espiritualidade de uma maneira lúdica e divertida, visando as formas em que podemos apresentar a astronomia.


<b>Mecanicas e Scripts a serem feitos</b>:

Sistemas e arquiteturas (programação)

- PACKAGES a se usar
- DOTween Pro 
- Unity Atoms
- SO Architecture


Arquitetura das Cartas

Data:
- CardData (SO)

Componentes relevantes:
- CardBehaviour (Elas vão ser responsáveis em como usam as suas propriedades e os seus efeitos)

Manager:
- CardManager (ou CardFactory)

Arquitetura Geral do jogo:
- InputManager <i>(Controla os Inputs do Jogo (CursorClick, MousePosition))</i>
- BattleManager <i>(Controla os turnos / battle gauge)</i>
- PlayerActions <i>(Armazena a Stack de Efeitos das Cartas, limitado a 3-5 efeitos)</i>
- EnemyActions <i>(Armazena a Stack de Efeitos das Cartas limitado a 3-5 efeitos)</i>
- PlayerManager <i>(Controla e armazena os status do Player, ele também controla a própria interface dele, pode entrar no)</i>
- GameManager <i>(Controla o fluxo padrão do Jogo) (Pausa, Sai, Da tela de Vitória, tem referência de todas classes importantes do jogo)</i>
- AudioManager <i>(Controla os Áudios (FMOD ou Audio normal))</i>
- TutorialManager <i>(Mostra o Tutorial do Jogo)</i>
- MenuManager <i>(Controla coisas do Menu (Efeitos, sequences))</i>

Componentes de Mouse:
- DragAndDropController (Para poder mover as cartas pelo cenário)
- Componentes de Arte Técnica (Bonitinho):

<b><div style="color:#DE3163"> Componentes Artisticos | Game Feels</div></b> 🌈
- UIFade (Faz o fade de um Objeto)
- UIScale  (Controla o scale de um Objeto)
- UIFillBar (Faz o efeito de controlar uma Barra)




