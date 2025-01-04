using UnityEngine;


public class HouseUpgrade: IUpgrade
{
    public string UpgradeType => "House";

    public int _level { get; private set; } = 0;
    private readonly actionPointsManager _actionPointsManager;

    [SerializeField] private Transform _houseLocation;
    [SerializeField] private GameObject[] _housePrefabs;
    private GameObject _currentInstance;

    // Standardrotation för initial prefab
    private readonly Quaternion _initialRotation = Quaternion.Euler(0, 90, -25);

    //Prefab lvl 2
    private readonly Quaternion _levelTwoRotation = Quaternion.Euler(12, 180, 0);
    private readonly Vector3 _levelTwoPosition = new Vector3(-3.5f, -3.5f, 3);

    public HouseUpgrade(actionPointsManager ActionPointsManager, Transform houseLocation, GameObject[] housePrefabs)
    {
        _actionPointsManager = ActionPointsManager;
        _houseLocation = houseLocation;
        _housePrefabs = housePrefabs;

    }

    public void Initialize()
    {        
            _currentInstance = GameObject.Instantiate(_housePrefabs[0], _houseLocation.position, _initialRotation);
        _currentInstance.SetActive(true);
    }

    public void ApplyUpgrade()
    {
        if (_level < _housePrefabs.Length - 1)
        {
            _level++;

            // Byt ut det gamla objektet mot det nya
            if (_currentInstance != null)
            {
                GameObject.Destroy(_currentInstance);
            }

            //Justera Lvl 2 Hus
            if(_level == 2)
            {
                Debug.Log("House lvl: " + _level);
                _currentInstance = GameObject.Instantiate(_housePrefabs[_level], _houseLocation.position, _levelTwoRotation);
                _currentInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.2f);
                _currentInstance.transform.position= _levelTwoPosition;
                Debug.Log("Position: " + _currentInstance.transform.position);
            }
            else
            {
          
            // Instansiera nästa husnivå
            _currentInstance = GameObject.Instantiate(_housePrefabs[_level], _houseLocation.position, Quaternion.identity);
                //GameObject newHouse = Object.Instantiate(_housePrefabs[_level], _houseLocation);
                //newHouse.transform.localPosition = Vector3.zero;
            }
            _actionPointsManager.changeBaseActionPoints(4); // Öka action points för varje uppgradering

        }

       
        Debug.Log($"House upgraded to level {_level}.");
    }

}
