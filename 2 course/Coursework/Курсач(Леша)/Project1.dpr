program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {FormDinozavr},
  Unit2 in 'Unit2.pas' {LogReg},
  Unit3 in 'Unit3.pas' {LogOut},
  Unit4 in 'Unit4.pas' {FormTest},
  Unit5 in 'Unit5.pas' {Form5},
  Unit6 in 'Unit6.pas' {Form6};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TFormDinozavr, FormDinozavr);
  Application.CreateForm(TFormTest, FormTest);
  Application.CreateForm(TLogReg, LogReg);
  Application.CreateForm(TLogOut, LogOut);
  Application.CreateForm(TForm5, Form5);
  Application.Run;
end.
