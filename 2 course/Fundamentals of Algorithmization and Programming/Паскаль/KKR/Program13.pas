program Est;

var
  a, b, u, v, min: real;

begin
  write('Введите А: ');
  readln(A);
  write('Введите B: ');
  readln(B);
  min := 3.14;
  u := min * (b);
  v := min * (a + b);
  writeln('Решенные уравнения второй части(U,V,MIN): ', u, ' ', v, ' ', min);
  u := min * (a);
  v := min * (a * b);
  min := u + sqr(v);
  writeln('Решенные уравнения первой части(U,V,MIN): ', u, ' ', v, ' ', min);
end.