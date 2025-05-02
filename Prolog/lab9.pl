%Задание 2 (Вар 7)

proiz_cifr(0,1) :- !.
proiz_cifr(N,P) :- Cifr is N mod 10, N1 is N div 10, proiz_cifr(N1, P1), P is P1 * Cifr.

proiz_cifr_down(N,P) :- proiz_cifr_down(N,1,P).
proiz_cifr_down(0,Pr,Pr) :- !.
proiz_cifr_down(N,Cur_pr,Pr) :- Cifr is N mod 10, N1 is N div 10, New_cur_pr is Cur_pr * Cifr,
 				proiz_cifr_down(N1,New_cur_pr,Pr).

count_odd_up(0,0) :- !.
count_odd_up(N,C) :- Cifr is N mod 10, N1 is N div 10, count_odd_up(N1,C1), 
	((Cifr > 3, 1 is Cifr mod 2) -> C is C1 + 1;
	C is C1).

count_odd_down(N,C) :- count_odd_down(N,0,C).
count_odd_down(0,Count,Count) :- !.
count_odd_down(N,Cur_count,Count) :- Cifr is N mod 10, N1 is N div 10, 	
				((Cifr > 3, 1 is Cifr mod 2) -> New_cur_count is Cur_count + 1;
				New_cur_count is Cur_count),
 				count_odd_down(N1,New_cur_count,Count).

gcd(0, N, N) :- !.
gcd(N, 0, N) :- !.
gcd(N1, N2, Result) :-
    N1 >= N2 -> Nod is N1 mod N2, gcd(Nod, N2, Result);
    gcd(N2, N1, Result).



%Задание 3 (Вар 7)

shift(List,Shift) :- shift_right(List,Shifted_list,Shift), write_list(Shifted_list), !.

write_list([]) :- !.
write_list([H|T]) :- write(H), write(","), write_list(T).

shift_right(List,Shifted_list,Shift) :- length(List,Len), (Len >= Shift -> SplitPos is Len - Shift,
        length(FirstPart,SplitPos), append(FirstPart,LastTwo,List),
        append(LastTwo,FirstPart,Shifted_list); New_shift is Shift - Len, shift_right(List,Shifted_list,New_shift)).


sum_even(List, Sum) :- sum_even_el(List, Sum), write(Sum), nl, !.

sum_even_el([], 0).

sum_even_el([H|T], Sum) :- sum_even_el(T, TempSum), (is_even(H) -> Sum is TempSum + H; Sum = TempSum).

is_even(Number) :-
    0 is Number mod 2.







