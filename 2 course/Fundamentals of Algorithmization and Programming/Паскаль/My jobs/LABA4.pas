Program Est;
Var
	a,n,i,p: Integer;
Begin
	Write('n='); {Степень}
	Readln(n);
	Write('a='); {Возводимое число}
	Readln(a);
	p:=1;
	For i:=1 To n Do p:=p*a;
	Write('p=',p);
End.