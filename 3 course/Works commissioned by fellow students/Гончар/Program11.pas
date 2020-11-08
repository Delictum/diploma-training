//Осуществить ввод общей информации по книгам 
//(автор, название, год издания, количества страниц), 
//вывести книги по дате выпуска в убывающем порядке.
type
  rab = record 
    fam1: string[20];
    fam2: string[20];
    zrp1: longint;
    zrp2: longint;
  end;

var
  inp, out: text;
  z: array[1..10] of rab;
  x: rab;
  k, n, i, j, t, c: integer;
  s: string;

begin
  assign(inp, 'input.txt'); {устанавливаем связь файловой переменной с физическим файлом на диске}
  reset(inp);
  assign(out, 'output.txt');
  rewrite(out); {открываем файл для записи}
  read(inp, n); {считываем кол-во данных строк из файла}
  writeln(n); {выводим строки в паскаль}
  readln(inp, s); {считываем последовательно текст строк из файла}
  for i := 1 to n do
  begin
    readln(inp, z[i].fam1); {считываем в массив}
    writeln(z[i].fam1); {выводим в консоль массив}
    readln(inp, z[i].fam2); {считываем в массив}
    writeln(z[i].fam2); {выводим в консоль массив}
    readln(inp, s); {считываем сроку типа string}
    val(s, t, c); {переводим строку в число}
    z[i].zrp1 := t; {записываем текст в массив}
    writeln(z[i].zrp1); {выводим на экран}
    readln(inp, s); {считываем сроку типа string}
    val(s, t, c); {переводим строку в число}
    z[i].zrp2 := t; {записываем текст в массив}
    writeln(z[i].zrp2); {выводим на экран}
  end;
  close(inp);
  
  for i := 1 to n do
    for j := n downto i do
      if (z[i].zrp1 <= z[j].zrp1) then
      begin              
        x := z[i];
        z[i] := z[j];
        z[j] := x;          
      end;

  for i := 1 to n do
  begin
    writeln(out, z[i].fam1);
    writeln(out, z[i].fam2);
    writeln(out, z[i].zrp1);
    writeln(out, z[i].zrp2);
  end;
  close(out);
  write('” Файл переписан!');
end.