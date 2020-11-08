program Project1;

uses
  Vcl.Forms,
  Unit2 in 'Unit2.pas' {LogReg},
  Unit3 in 'Unit3.pas' {LogOut},
  Unit5 in 'Unit5.pas' {FormBegin},
  Unit6 in 'Unit6.pas' {FormGame1},
  Unit7 in 'Unit7.pas' {FormGame2},
  Unit8 in 'Unit8.pas' {FormGame3},
  Unit9 in 'Unit9.pas' {FormEnd},
  Unit10 in 'Unit10.pas' {Form10},
  Unit11 in 'Unit11.pas' {FormADMIN},
  Unit12 in 'Unit12.pas' {Form12};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TLogOut, LogOut);
  Application.CreateForm(TFormBegin, FormBegin);
  Application.CreateForm(TLogReg, LogReg);
  Application.CreateForm(TFormGame1, FormGame1);
  Application.CreateForm(TFormGame2, FormGame2);
  Application.CreateForm(TFormGame3, FormGame3);
  Application.CreateForm(TFormEnd, FormEnd);
  Application.CreateForm(TFormADMIN, FormADMIN);
  Application.CreateForm(TForm12, Form12);
  Application.Run;
end.
