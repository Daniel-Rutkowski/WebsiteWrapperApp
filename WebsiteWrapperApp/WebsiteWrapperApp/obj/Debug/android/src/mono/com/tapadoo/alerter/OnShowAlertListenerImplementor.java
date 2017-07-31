package mono.com.tapadoo.alerter;


public class OnShowAlertListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.tapadoo.alerter.OnShowAlertListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onShow:()V:GetOnShowHandler:Com.Tapadoo.Alerter.IOnShowAlertListenerInvoker, Alerter\n" +
			"";
		mono.android.Runtime.register ("Com.Tapadoo.Alerter.IOnShowAlertListenerImplementor, Alerter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnShowAlertListenerImplementor.class, __md_methods);
	}


	public OnShowAlertListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnShowAlertListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Tapadoo.Alerter.IOnShowAlertListenerImplementor, Alerter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onShow ()
	{
		n_onShow ();
	}

	private native void n_onShow ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
