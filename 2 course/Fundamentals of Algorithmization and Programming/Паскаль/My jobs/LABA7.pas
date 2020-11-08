var
  mas: array[1..1000] of integer;
  mass: array[1..1000] of real;
  s, h, z, i, j, n, e, f: integer;

function e_N(z_n: integer): integer;
Var i:integer;
begin
  for i := 1 to n do
  if mas[i] < 0 then z_n := 1 + z_n; 
writeln('Количество отрицательных: ',z_n,' '); 
end;

function e_H(s_n: integer): integer;
Var i:integer;
begin
  for i := 1 to n do
  if mas[i] mod 2 = 0 then s_n := s_n + mas[i];
  write('Сумма положительных элементов, кратных двум: ',s_n); 
end;

begin
  write('Введите N: ');readln(n);  
  for j := 1 to n do 
  begin
    mass[j] := random(100) / (1 + random(10)) - random(7);
    writeln(mass[j]:10:2);
  end;
  j := 0;
  for i := 1 to n do
  begin
    j := j + 1;
    mas[i] := round(mass[j]);
  end;
  for i := 1 to n do                               
    writeln(mas[i]);                                                       
  e_N(z);                                                          
  e_H(s); 
end.