Uses CRT;
label Out;
const
  N = 5;

var
  C: array [1..N, 1..N] of word; 
  Tour, P: array [1..N] of word; 
  l, s: word;
  i, j, k, min, ind: byte;
  All: boolean;

begin
  ClrScr;
  {Ввод данных}
  WriteLn('Матрица смежности:');
  c[1, 1] := 0; c[1, 2] := 6; c[1, 3] := 9; c[1, 4] := 2; c[1, 5] := 4;
  c[2, 1] := 6; c[2, 2] := 0; c[2, 3] := 2; c[2, 4] := 6; c[2, 5] := 2;
  c[3, 1] := 6; c[3, 2] := 3; c[3, 3] := 0; c[3, 4] := 3; c[3, 5] := 3;
  c[4, 1] := 5; c[4, 2] := 7; c[4, 3] := 3; c[4, 4] := 0; c[4, 5] := 6;
  c[5, 1] := 3; c[5, 2] := 2; c[5, 3] := 2; c[5, 4] := 5; c[5, 5] := 0;
  
  for i := 1 To N Do
  begin
    for j := 1 To N Do Write(C[i, j], ' ');
    WriteLn;
  end;
  
  All := False; 
  l := MaxInt; 
  for i := 1 To N Do P[i] := i; 
  repeat
    
    s := 0;
    for i := 1 To N - 1 Do s := s + C[P[i], P[i + 1]];
    s := s + C[P[n], P[1]];
    if l > s Then
    begin
      Tour := P;
      l := s;
    end;
    for i := N DownTo 3 do
    begin
      if P[i] < P[i - 1] Then continue;
      min := N + 1;
      k := P[i - 1];
      for j := i To N Do 
        if (P[j] > k) and (P[j] < min) Then
        begin
          min := P[j];
          ind := j;
        end;
      P[i - 1] := min;
      P[ind] := k;
      for j := i To N - 1 Do
      begin
        min := N + 1;
        for k := j To N Do 
          if min > P[k] Then
          begin
            min := P[k];
            ind := k;
          end;
        k := P[j];
        P[j] := min;
        P[ind] := k;
      end;
      goto out;
    end;
    All := true;
    Out: 
  until All;
  {Если перебраны все перестановки, то выдаем оптимальный тур}
  Write('Минимальный тур: ');
  for i := 1 To N Do Write(Tour[i], '-');
  Write('1');
  WriteLn(' имеет длину ', l);
  ReadKey;
end.