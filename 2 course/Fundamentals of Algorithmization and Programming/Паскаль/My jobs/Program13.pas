program Est;

const
  b: set of char = ['�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�'];

var
  p: set of char;
  d: set of char;
  str: string;
  i: byte;

begin
  p := [];
  d := [];
  write('������� ������: ');
  readln(str);
  for i := 1 to length(str) do
    if str[i] in b then p := p + [str[i]];
  d := b - p;
  writeln(d);
end.