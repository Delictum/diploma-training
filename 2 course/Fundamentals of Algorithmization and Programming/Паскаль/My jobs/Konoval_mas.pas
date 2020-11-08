var
  mas: array[1..20] of integer;
  i, s, c, a, b: integer;

begin
  write('¬ведите A: ');
  readln(a);
  write('¬ведите B: ');
  readln(b);
  s := 0;
  c := b - a + 1;
  writeln('Ёлементы от 1 до 20: ');
  for i := 1 to 20 do
  begin
    mas[i] := random(30) - 15;
    write(mas[i]:4);
  end;
  writeln;
  writeln('Ёлементы от A до B: ');
  for i := a to b do
  begin
    write(mas[i]:4);
    if i mod 3 = 0 then s := s + mas[i];
  end;
  writeln;
  writeln('—умма: ', s);
  writeln(' оличество чисел в промежутке от A до B: ', c);
end.