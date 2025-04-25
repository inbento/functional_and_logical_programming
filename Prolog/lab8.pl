father(X,Y) :- man(X), parent(X,Y), nl.
father(Y) :- father(X,Y), print(X).

sister(X,Y) :-  woman(X), X \=Y, parent(Z,X), parent(Z,Y).
sisters(X) :- sister(Y,X), Y \=X, print(Y), nl, !.