type
  comp = (pII, pIII, pIV, Cel, At);
  kol = set of comp;

const
  nn = 5;
  sp: array[0..nn - 1] of string = ('PentiumII', 'Pentium III', 'Pentium IV', 'Celeron', 'Atlon');

var
  m: array[1..nn] of kol;
  res: kol;
  j: comp;
  i, ii, k, p: byte;
  nz: string;

begin
  writeln('Перечислите какие компьютеры есть в колледже:');
  for i := 1 to nn do
  begin
    writeln('Колледж №', i);
    m[i] := [];
    writeln('0-PentiumII 1-Pentium III 2-Pentium IV 3-Celeron 4-Atlon');
    writeln('5-выход');
    repeat
      readln(k);
      if k in [0..4] then m[i] := m[i] + [comp(k)];
    until k = 5;
  end;
  writeln('Есть во всех колледжах:');
  res := [];
  for j := pII to At do
  begin
    for ii := 1 to nn do
    for i := 1 to nn do
    res := m[ii]*m[i];
  end;
  for j := pII to At do
    if j in res then write(sp[ord(j)], ' ');
  writeln;
end.