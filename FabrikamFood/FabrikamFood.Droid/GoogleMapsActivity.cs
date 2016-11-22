using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;

namespace FabrikamFood.Droid
{
    [Activity(Label = "GoogleMapsActivity")]
    public class GoogleMapsActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Setup google maps
            setUpGoogleMaps();

            /*MapFragment mapFrag = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            GoogleMap map = mapFrag.Map;
            if (map != null)
            {
                map.MapType = GoogleMap.MapTypeSatellite;
            }*/
      
        }

        private void setUpGoogleMaps()
        {
            if (mMap != null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
                mMap.MapType = GoogleMap.MapTypeSatellite;
            }
        }
    }
}