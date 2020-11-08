program Est;

var
  s, m, f: real;
  i: integer;

begin
  write('¬ведите кол-во задолженности: ');
  readln(s);
  write('—суда: ');
  readln(m);
  f := m;
  repeat
    m := m * 1.2;
    i := i + 1;
  until m > s;
  write('„ерез ', i, ' лет задолженность превысит ссуду');
end.