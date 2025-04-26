%максимум двух чисел(принимает X,Y в Z хранится максимум)

%max(X,Y,Z) :- X>Y, Z is X

max(X,Y,X) :- X>Y, !.
%max(X,Y,Y). будет жаловатся, что Х не используется, потому сделаем так:
max(_,Y,Y).


%максимум 3-х

max(X,Y,Z,U) :- max(X,Y,V), max(V,Z,U).

max3(X,Y,Z,X) :- X>Y, X>Z, !.
max3(_,Y,Z,Y) :- Y>Z, !.
max3(_,_,Z,Z).

%сумма цифр(рекурсия вверх)

sum_cifr(0,0):- !.
sum_cifr(N,S) :- Cifr is N mod 10, N1 is N div 10, sum_cifr(N1, S1), S is S1 + Cifr.

%сумма цифр(рекурсия вниз)

sum_cifr_down(N,S) :- sum_cifr_down(N,0,S).
sum_cifr_down(0,Sum,Sum) :- !.
sum_cifr_down(N,Cur_sum,Sum) :- Cifr is N mod 10, N1 is N div 10, New_cur_sum is Cur_sum + Cifr,
				sum_cifr_down(N1,New_cur_sum,Sum).


%списки(они же списки Черча)

write_list([]) :- !.
write_list([H|T]) :- write(H), nl, write_list(T).

summ_spisok([H|T],S) :- summ_spisok([H|T],0,S).
summ_spisok([],Sum, Sum) :- !.
summ_spisok([H|T],Cur_sum, Sum) :- New_cur_sum is Cur_sum + H, summ_spisok(T, New_cur_sum, Sum).

%вложенные предикаты со списками. Базовые:
%append
%member - проверяет есть ли эл в списке.
%nth0
%reverse

