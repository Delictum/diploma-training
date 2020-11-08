program Est;

var
  g, r, x, y: real;

procedure okrug(a, c: real);
begin
  if r > 0 then
  begin
    a := 2 * r * 3.14;
    c := 3.14 * sqr(r);
    write('Длина окружности: ', a, '. Площадь окружности: ', c, '.');
  end
  else write('Окружность не существует.');
end;

begin
  write('Введите радиус: ');
  readln(r);
  okrug(x, y);
end.
