program Est;

type
  mss = ^mas;
  mas = array of integer;

var
  a: mss;
  i, s, n, j: byte;
  sr: real;

begin
  s := 0;
  write('¬ведите кол-во элементов массива N-1: ');
  readln(n);
  new(a);
  setlength(a^, n); 
  for i := 1 to a^.Length - 1 do
  begin
    a^[i] := random(7) + 1;
    write(a^[i], ' ');
    s := s + a^[i];
    j := i;
  end;
  sr := s / j;
  writeln;
  writeln('—реднее значение: ', sr);
  dispose(a);
end.