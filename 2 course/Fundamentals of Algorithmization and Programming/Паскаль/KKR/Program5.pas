program Est;

var
  a, b, c, p, s, pr: real;

begin
  write('������� ����� �������� a, b � c: ');
  readln(a, b, c);
  P := a + b + c;
  pr := p / 2;
  S := sqrt(pr * (pr - a) * (pr - b) * (pr - c));
  if (a > 0) and (b > 0) and (c > 0) then write('��������: ', p, '. �������: ', s) 
  else write('������������ �� ����������');
  if not (a < b + c) or (b < a + c) or (c < a + b) then write('������������ �� ����������');
end.