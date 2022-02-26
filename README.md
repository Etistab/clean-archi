# clean-archi

## Commentaires sur le code et sa structure

Le premier problème qui nous saute aux yeux est le mise en forme et l'indentation du code.

En regardant d'un peu plus prêt, on remarque que tout le code métier est mélanger à la "plomberie". Il faudrait séparer les deux.

Aussi, certaines variables pourraient avoir des noms plus appropriés (on pense notamment un number1, number2, etc..).

Enfin, il faudrait clairement séparer cet énorme bloc de code illisible en plusieurs petites fonctions testables unitairement.


## Proposition de structuration du code

Nous pouvons deja separé tout le "noyau" du programme s'occupant de gérer la donnée.

Nous pouvons ensuite créer une partie gérant uniquement l'interface utilisateur et les prints.

Enfin nous aurons un composant central qui regroupera le code métier et qui interagira avec nos différents composants.

Pour finir nous ajouterons un composants permettant de filtrer les entrées de notre programme.
	

## Proposition de stratégie de tests

Notre but est de fragmenter le programme en un maximum de fonctions pures afin de pouvoir les tester facilement et efficacement , unitairement.

Les fonctions les plus intéressantes a tester seront celles verifiant les entrées du programme. Elles représentent une barrière essentielle pour le bon fonctionnement du programme.

Enfin le code métier sera lui aussi evidemment essentiel à tester pour garantir la réussite du programme.