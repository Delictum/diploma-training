Program Est;
Var
   mas: array [1..10] of integer;
   i,x: integer;
Begin
   For i:=1 to 10 do {���������� �������}
   readln(mas[i]);
   For i:=1 to 10 do
   write(mas[i],' '); { ����� ������� }
   x:=mas[2];
   mas[2] := mas[7];
   mas[7] := x;
   writeln(mas[2],' ',mas[7]);
end. 