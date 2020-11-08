Program Est;
Var
   mas: array [1..20] of real;
   i: integer;
Begin
   mas[1]:=7; { присваивание первому массиву значение 7 }
   For i:=2 to 20 do {«аполнение массива}
   mas[i]:=mas[i-1]*3; {√еометрическа€ прогресси€ дл€ элементов массива}
   For i:=1 to 20 do
   writeln (mas[i],' ',i); { вывод массива }
end. 