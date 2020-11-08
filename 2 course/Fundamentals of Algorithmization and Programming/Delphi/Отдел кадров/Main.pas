unit Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Vcl.StdCtrls, Vcl.ExtCtrls, Data.Win.ADODB;

type
  TFName = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    Panel3: TPanel;
    Splitter1: TSplitter;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    Bevel1: TBevel;
    Label1: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Bevel2: TBevel;
    DBGrid1: TDBGrid;
    DBGrid2: TDBGrid;
    ADOConnection1: TADOConnection;
    TLichData: TADOTable;
    TDoljnost: TADOTable;
    TTelphones: TADOTable;
    TAdress: TADOTable;
    DSLichData: TDataSource;
    DSDoljnost: TDataSource;
    DSTelephones: TDataSource;
    DSAdress: TDataSource;
    TLichData����: TAutoIncField;
    TLichData�������: TWideStringField;
    TLichData���: TWideStringField;
    TLichData��������: TWideStringField;
    TLichData���: TWideStringField;
    TLichData���_�����: TBooleanField;
    TLichData�����: TWordField;
    TLichData����_����: TDateTimeField;
    TLichData����_����: TDateTimeField;
    TLichData����: TWordField;
    TLichData�����������: TWideStringField;
    TLichData���������������: TBooleanField;
    TDoljnost���������: TIntegerField;
    TDoljnost�����: TWideStringField;
    TDoljnost���������: TWideStringField;
    TTelphones���������: TIntegerField;
    TTelphones�������: TWideStringField;
    TTelphones����������: TWideStringField;
    TAdress���������: TIntegerField;
    TAdress������: TWideStringField;
    TAdress�����: TWideStringField;
    TAdress���_�����: TWideStringField;
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure DBGrid2DblClick(Sender: TObject);
    procedure RadioButton1Click(Sender: TObject);
    procedure RadioButton2Click(Sender: TObject);
    procedure RadioButton3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FName: TFName;

implementation

{$R *.dfm}

uses Edit;

procedure TFName.Button2Click(Sender: TObject);
begin
FEditor.ShowModal;
end;

procedure TFName.Button3Click(Sender: TObject);
begin
  FName.TLichData.Append;
  FName.TDoljnost.Append;
  FName.TAdress.Append;
  FName.TTelphones.Append;
  FEditor.ShowModal;
end;

procedure TFName.DBGrid2DblClick(Sender: TObject);
begin
  FEditor.ShowModal;
end;

procedure TFName.RadioButton1Click(Sender: TObject);
begin
  if RadioButton1.Checked then
    DBGrid1.DataSource := DSADress;
end;

procedure TFName.RadioButton2Click(Sender: TObject);
begin
if RadioButton2.Checked then
    DBGrid1.DataSource := DSTelephones;
end;

procedure TFName.RadioButton3Click(Sender: TObject);
begin
if RadioButton3.Checked then
    DBGrid1.DataSource := DSDoljnost;
end;

end.

