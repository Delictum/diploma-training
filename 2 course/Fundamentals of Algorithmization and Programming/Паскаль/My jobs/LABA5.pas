Program Est;
Var
   mas: array [1..20] of real;
   i: integer;
Begin
   mas[1]:=7; { ������������ ������� ������� �������� 7 }
   For i:=2 to 20 do {���������� �������}
   mas[i]:=mas[i-1]*3; {�������������� ���������� ��� ��������� �������}
   For i:=1 to 20 do
   writeln (mas[i],' ',i); { ����� ������� }
end. 