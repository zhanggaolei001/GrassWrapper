namespace GrassWrapper.Enum
{
    public enum SourceType
    {
        TypeMapLayer = -2, //!< Any map layer type (raster or vector or mesh)
        TypeVectorAnyGeometry = -1, //!< Any vector layer with geometry
        TypeVectorPoint = 0, //!< Vector point layers
        TypeVectorLine = 1, //!< Vector line layers
        TypeVectorPolygon = 2, //!< Vector polygon layers
        TypeRaster = 3, //!< Raster layers
        TypeFile = 4, //!< Files (i.e. non map layer sources, such as text files)
        TypeVector = 5, //!< Tables (i.e. vector layers with or without geometry). When used for a sink this indicates the sink has no geometry.
        TypeMesh = 6 //!< Mesh layers \since QGIS 3.6
    };


  
}
