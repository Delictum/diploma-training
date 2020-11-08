program Est;

type
  mss = ^mas;
  mas = array of integer;

var
  a: mss;
  max, i, n, buf, k, D: longint;

begin
  new(a);
  write('Введите кол-во элементов массива N-1: ');
  readln(n);
  write('Задайте D: ');
  readln(D);
  setlength(a^, n);
      Swap(a^[a^.Length - 1], a^[a^.LastIndexMax]);
  for i := 1 to a^.Length - 1 do
  begin
    a^[i] := random(7) + 1;
    write(a^[i],' ');
    a^[i] := d * a^[i];
  end;
    writeln;
  writeln('Итоговое расположение элементов: ');  
  for i := 1 to a^.Length - 1 do
    write(a^[i],' ');
  writeln;
  writeln('Перемноженные элементы: ', d);
end.

