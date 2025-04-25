father(X,Y) :- man(X), parent(X,Y), nl.
father(Y) :- father(X,Y), print(X).

sister(X,Y) :-  woman(X), X \=Y, parent(Z,X), parent(Z,Y).
sisters(X) :- sister(Y,X), Y \=X, print(Y), nl, !.

grand_pa(X,Y) :- man(X), parent(X,Z), parent(Z,Y).
grand_pas(X) :- grand_pa(Y,X), print(Y), nl, fail.

grand_pa_and_son(X,Y) :- grand_pa(X,Y); grand_pa(Y,X).

bro_or_sis(X,Y) :- parent(Z, X), parent(Z, Y), X \=Y.
uncle(X,Y) :- man(X), parent(Z,Y), bro_or_sis(X,Z), X\=Z.
uncles(X) :- uncle(Y,X), X \= Y, print(Y), nl, fail.
