program Est;

const
  b: set of char = ['б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'];

var
  p: set of char;
  d: set of char;
  str: string;
  i: byte;

begin
  p := [];
  d := [];
  write('¬ведите строку: ');
  readln(str);
  for i := 1 to length(str) do
    if str[i] in b then p := p + [str[i]];
  d := b - p;
  writeln(d);
end.