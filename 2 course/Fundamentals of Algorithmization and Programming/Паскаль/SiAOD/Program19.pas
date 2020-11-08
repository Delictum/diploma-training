type
  vector = array[1..3] of real;
  matrix = array[1..3, 1..3] of real;

const
  n: integer = 3;
  e: real = power(10, -5);

var
  i, j, k, max: integer;
  Ek, sum1, sum2: real;
  a, alpha: matrix;
  b, beta, x_curr, x_prev, x_tmp: vector;

begin
  
  a[1, 1] := -3;  a[1, 2] := 0.5; a[1, 3] := 0.5; b[1] := -56.65;
  a[2, 1] := 0.5; a[2, 2] := -6;  a[2, 3] := 0.5; b[2] := -160;
  a[3, 1] := 0.5; a[3, 2] := 0.5; a[3, 3] := -3;  b[3] := -210;
  
  Writeln('Исходная матрица имеет вид: ');
  for i := 1 to n do 
  begin
    for j := 1 to n do
      write('  ', a[i, j]:1:3);
    writeln;
  end;
  
  Writeln('Преобразованная матрица имеет вид: ');
  for i := 1 to n do 
  begin
    for j := 1 to n do
      if i <> j then
        alpha[i, j] := (-a[i, j]) / (a[i, i])
      else
        alpha[i, j] := 0;
  end;
  for i := 1 to n do 
  begin
    for j := 1 to n do
      write('  ', alpha[i, j]:1:3);
    writeln;
  end;
  
  Writeln('Проверим достаточное условие сходимости итерационной последовательности: ' );
  for i := 1 to n do 
  begin
    for j := 1 to n do
      Ek := Ek + sqr(alpha[i, j]);
  end;
  Ek := sqrt(Ek);
  
  if Ek > 1 then
  begin
    writeln('  Eвклидова норма матрицы ', Ek:1:3, ' > 1. Условие не выполнено.');
    exit;
  end
      else
  begin
    writeln('  Eвклидова норма матрицы ', Ek:1:3, ' < 1. Условие выполнено.');
  end;
  
  Ek := 0;
  sum1 := 0;
  sum2 := 0;
  k := 0;
  
  for i := 1 to n do
    beta[i] := b[i] / a[i, i];
  
  repeat
    inc(k);
    if k <> 1 then
      for i := 1 to n do
        x_prev[i] := x_tmp[i];
    for i := 1 to n do
    begin
      sum1 := 0;
      for j := 1 to i - 1 do
        sum1 := sum1 + a[i, j] * x_prev[j];
      sum2 := 0;
      for j := i + 1 to n do
        sum2 := sum2 + a[i, j] * x_prev[j];
      x_curr[i] := (b[i] - sum1 - sum2) / a[i, i];
    end;
    for i := 1 to n do
      x_tmp[i] := x_curr[i];
    max := 1;
    for i := 1 to n - 1 do
      if abs(x_curr[max] - x_prev[max]) < abs(x_curr[i + 1] - x_prev[i + 1]) then
        max := i + 1;
  until abs(x_curr[max] - x_prev[max]) < e;
  writeln('Кол-во итераций = ', k);
  writeln('Корни системы: ');
  for i := 1 to n do
    write('  x[', i, '] = ', x_curr[i]:2:3);
end.