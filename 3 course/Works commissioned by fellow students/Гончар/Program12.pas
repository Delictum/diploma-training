//Написать рекурсивную процедуру для ввода с клавиатуры последовательности чисел 
//(окончание ввода -0) и вывода ее на экран в обратном порядке
Type
  mass = array[1..1000] of integer;

function rec(var a : mass; c : integer) : integer;
Var 
  i, n, count : integer;
begin  
  ReadLn(n);
  if (n <> 0) then
  begin
    a[c] := n;
    count := count + 1;
    rec := 1 + rec(a, c + 1);
  end;
end;

Var
  mas : mass;
  i, count : integer;
Begin
  count := 1;
  WriteLn('Введите последовательность чисел. Для прекращения ввода введите 0');
  count := rec(mas, count);
  writeln(count);
  for i := count downto 1 do
    Write(mas[i] + ' ');
End.