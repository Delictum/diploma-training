unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Data.DB,
  Vcl.Grids, Vcl.DBGrids, Datasnap.DBClient, Datasnap.Provider, Data.SqlExpr,
  Vcl.Menus, Vcl.StdCtrls;

type
  TFormAir = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    DataSource2: TDataSource;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    SQLQuery2: TSQLQuery;
    SQLQuery3: TSQLQuery;
    DataSetProvider3: TDataSetProvider;
    ClientDataSet3: TClientDataSet;
    DataSource3: TDataSource;
    DBGrid2: TDBGrid;
    DBGrid3: TDBGrid;
    MainMenu1: TMainMenu;
    MMProgram: TMenuItem;
    MMUserOut: TMenuItem;
    MMExitProg: TMenuItem;
    MMAED: TMenuItem;
    MMHelp: TMenuItem;
    BtnAllAir: TButton;
    BtnAllFlights: TButton;
    RefreshSQL: TMenuItem;
    ComboBox1: TComboBox;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure MMExitProgClick(Sender: TObject);
    procedure MMUserOutClick(Sender: TObject);
    procedure BtnAllAirClick(Sender: TObject);
    procedure BtnAllFlightsClick(Sender: TObject);
    procedure MMAEDClick(Sender: TObject);
    procedure RefreshSQLClick(Sender: TObject);
    procedure MMHelpClick(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormAir: TFormAir;

implementation

{$R *.dfm}

uses Unit1, Unit3, Unit7;

//���������� �������� �� �������������� � �������� ��� ���
procedure TFormAir.BtnAllAirClick(Sender: TObject);
begin
  if BtnAllAir.Caption = '��� ��������' then //���� ���������� ���...
  begin
    ClientDataSet2.MasterFields := '';     //���������� �� ��������
    BtnAllAir.Caption := '�� ������������';
    exit;
  end;
  if BtnAllAir.Caption = '�� ������������' then  //����� - ��������
  begin
    ClientDataSet2.MasterFields := 'AirlineID';
    BtnAllAir.Caption := '��� ��������';
    exit;
  end;
end;

//���������� ���������, �������������� �����...
procedure TFormAir.BtnAllFlightsClick(Sender: TObject);
begin
  if BtnAllFlights.Caption = '��� �����' then //���� ���������� ���...
  begin
    ClientDataSet3.MasterFields := '';     //���������� �� ���������
    BtnAllFlights.Caption := '�� ���������';
    exit;
  end;
  if BtnAllFlights.Caption = '�� ���������' then  //����� - ��������
  begin
    ClientDataSet3.MasterFields := 'AircraftID';
    BtnAllFlights.Caption := '��� �����';
    exit;
  end;
end;

procedure TFormAir.ComboBox1Change(Sender: TObject);
begin
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('UPDATE Flights Set FlightsStatusID = ' + IntToStr(ComboBox1.ItemIndex + 1));
  SQLQuery1.SQL.Add(' WHERE FlightsID = ' + FormAED.DBEditFlightsID.Text);
  SQLQuery1.ExecSQL;

  RefreshSQLClick(Self);
end;

//��� �������� ��������� ����� ��������� ����� �����������
procedure TFormAir.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormLog.Close;
end;

//����� �� ����� �������������
procedure TFormAir.MMUserOutClick(Sender: TObject);
begin
  FormAir.Hide;
  FormLog.Show;
end;

procedure TFormAir.RefreshSQLClick(Sender: TObject);
begin
  FormAir.ClientDataSet1.Active := false;
  FormAir.SQLQuery1.Close;
  FormAir.SQLQuery1.SQL.Clear;
  FormAir.SQLQuery1.SQL.Add('SELECT * FROM Airline');
  FormAir.SQLQuery1.Open;
  FormAir.ClientDataSet1.Active := true;

  FormAir.ClientDataSet2.Active := false;
  FormAir.SQLQuery2.Close;
  FormAir.SQLQuery2.SQL.Clear;
  FormAir.SQLQuery2.SQL.Add('SELECT * FROM Aircraft');
  FormAir.SQLQuery2.Open;
  FormAir.ClientDataSet2.Active := true;

  FormAir.ClientDataSet3.Active := false;
  FormAir.SQLQuery3.Close;
  FormAir.SQLQuery3.SQL.Clear;
  FormAir.SQLQuery3.SQL.Add('SELECT FlightsID, FlightsAircraftID, FlightsDepartureTime, ');
  FormAir.SQLQuery3.SQL.Add('FlightsArrivalTime, FlightsDeparturePoint, FlightsArrivalPoint, StatusName ');
  FormAir.SQLQuery3.SQL.Add('FROM Status, Flights WHERE FlightsStatusID = StatusID');
  FormAir.SQLQuery3.Open;
  FormAir.ClientDataSet3.Active := true;

  DBGrid1.Refresh;
  DBGrid2.Refresh;
  //DBGrid3.Refresh;
end;

procedure TFormAir.MMAEDClick(Sender: TObject);
begin
  FormAED.Show;
end;

//����� �� ���������
procedure TFormAir.MMExitProgClick(Sender: TObject);
begin
  FormAir.Close;
end;

procedure TFormAir.MMHelpClick(Sender: TObject);
begin
  FormHelp.Show;
end;

end.
