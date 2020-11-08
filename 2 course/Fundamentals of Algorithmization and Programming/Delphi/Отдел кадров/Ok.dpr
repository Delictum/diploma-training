program Ok;

uses
  Vcl.Forms,
  Main in 'Main.pas' {FName},
  Edit in 'Edit.pas' {FEditor};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFName, FName);
  Application.CreateForm(TFEditor, FEditor);
  Application.Run;
end.
